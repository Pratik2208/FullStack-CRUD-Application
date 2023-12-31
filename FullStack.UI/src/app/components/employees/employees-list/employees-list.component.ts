import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {

  employees : Employee[] = [

  ];

  constructor(private employeeService : EmployeesService){

  }

  ngOnInit() {
    this.employeeService.getAllEmployees()
    .subscribe({
      next: (employee) => {
        this.employees = employee;
      },
      error: (response) => {
        console.log(response);
      }
    })

  }

}
