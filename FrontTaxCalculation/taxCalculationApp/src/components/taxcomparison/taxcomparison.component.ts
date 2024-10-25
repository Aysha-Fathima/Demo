import { Component } from '@angular/core';
import { TaxService } from '../../services/tax.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgFor } from '@angular/common';
import { catchError, tap } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Component({
  selector: 'app-taxcomparison',
  standalone: true,
  imports: [FormsModule,NgFor],
  templateUrl: './taxcomparison.component.html',
  styleUrl: './taxcomparison.component.css'
})
export class TaxcomparisonComponent {
  restUserData: TaxService;
  constructor( restUserDataRef:TaxService,private router:Router)
  {
    this.restUserData=restUserDataRef;

  }

  // yeardata:any;

  ngOnInit() {
    this.restUserData.getYear();
    // console.log(this.restUserData.totalYears);
  }
  
  

  // getYear() {
  //   this.restUserData.getYear().subscribe(
  //     (data: any) => {
  //       console.log(data); // Check the response
  //       // this.totalYears = data; // Store the data
  //       // this.FirstOption = data; // Assuming you want to use this data for dropdown
  //       // this.SecondOption = data; // Adjust if needed
  //     }
  //   );
  // }


  // firstOption = this.restUserData.totalYears;


  FirstOption = [2024,2023,2022,2021];
  SecondOption = [2024,2023,2022,2021];
  
  FirstYear: number = 0;
  SecondYear: number = 0;

}
