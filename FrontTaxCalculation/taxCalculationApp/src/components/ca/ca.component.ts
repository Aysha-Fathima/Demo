import { Component } from '@angular/core';
import { TaxService } from '../../services/tax.service';
import { Router } from '@angular/router';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-ca',
  standalone: true,
  imports: [NgFor,FormsModule,NgIf],
  templateUrl: './ca.component.html',
  styleUrl: './ca.component.css'
})
export class CaComponent {
  restUserData: TaxService;
  constructor( restUserDataRef:TaxService,private router:Router)
  {
    this.restUserData=restUserDataRef;

  }

  ngOnInit(){
    this.restUserData.getAllUsers();
  }
}
