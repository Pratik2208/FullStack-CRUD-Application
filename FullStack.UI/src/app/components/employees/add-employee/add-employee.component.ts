import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit{

  addEmployeeRequest : Employee = {
    id : '',
    name : '',
    email : '',
    phone : 0,
    salary : 0,
    department : ''
  }

  ngOnInit() {

  }

  constructor(private employeeService :EmployeesService , private router : Router){}

  addEmployee(){
    /* console.log(this.addEmployeeRequest); */
    this.employeeService.addEmployee(this.addEmployeeRequest)
    .subscribe({
      next : (employee) => {
        this.router.navigate(['employee'])
      }
    })
  }

}
