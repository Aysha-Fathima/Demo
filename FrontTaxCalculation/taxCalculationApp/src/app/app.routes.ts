import { Routes } from '@angular/router';
import { RegisterComponent } from '../components/register/register.component';
import { AboutUsComponent } from '../components/about-us/about-us.component';
import { LoginComponent } from '../components/login/login.component';
import { TaxcalculationComponent } from '../components/taxcalculation/taxcalculation.component';
import { HomeComponent } from '../components/home/home.component';
import { TaxcomparisonComponent } from '../components/taxcomparison/taxcomparison.component';
import { ChartComponent } from '../components/chart/chart.component';
import { CaComponent } from '../components/ca/ca.component';

export const routes: Routes = [
    {path:"home", component:HomeComponent},
    {path:"register", component:RegisterComponent},
    {path:"login", component:LoginComponent},
    {path:"aboutUs", component:AboutUsComponent},
    {path: 'taxcalculation', component: TaxcalculationComponent},
    {path: 'taxcomparison', component: TaxcomparisonComponent},
    {path: 'chart', component: ChartComponent},
    {path: 'ca', component: CaComponent},
    {path: '', redirectTo: 'home', pathMatch: 'full' }
];
