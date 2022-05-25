using EmployeeApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options => { options.AddDefaultPolicy(policy => { policy.WithOrigins("*"); }); });
            var app = builder.Build();
            app.UseCors();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();



            ProgramUI ui = new ProgramUI();
            IEmployeeRepository employeeRepository = new EmployeeFileRepository();

            IEmployeeService service = new EmployeeService(employeeRepository);


            int selectedOption = 0;
            while (selectedOption != 6)
            {
                ui.DisplayMenu();
                selectedOption = ui.GetSelecedOption();
                switch (selectedOption)
                {
                    case 1:
                        employeeRepository.AddEmployee(ui.GetEmployeeUser());
                        break;

                    case 2:
                        ui.DisplayEmployeesList(employeeRepository.GetEmployees());
                        break;

                    case 3:
                        employeeRepository.DeleteEmployee(employeeRepository.GetEmployeeByFirstNameAndLastName(ui.GetFirstNameToDelete(), ui.GetLastNameToDelete()));
                        break;

                    case 4:
                        ui.IsEmpoyeeExist(employeeRepository.GetEmployeeByFirstNameAndLastName(ui.GetFirstName(), ui.GetLastName()));
                        break;

                    case 5:
                        ui.DisplayStats(service.GetMaxSalary(), service.GetMinSalary(), service.GetAvarageSalary(), service.GetNumberOfEmployees());
                        break;

                    case 6:
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            }


            Console.ReadKey();


        }


    }



}
