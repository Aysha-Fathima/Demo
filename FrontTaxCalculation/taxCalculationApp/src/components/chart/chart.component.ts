import { Component, OnInit } from '@angular/core';
import { TaxService } from '../../services/tax.service';
import { Router } from '@angular/router';
import { Chart, registerables } from 'chart.js';

@Component({
  selector: 'app-chart',
  standalone: true,
  imports: [],
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.css'
})
export class ChartComponent implements OnInit{
  restUserData: TaxService;
  constructor( restUserDataRef:TaxService,private router:Router)
  {
    this.restUserData=restUserDataRef;

  }

  // constructor(private restUserData: RestUserDataService) {}

  

  
    chart: any;
    chartLabel:string[] = [];
    chartData:number[] = [];
    ngOnInit() {
      let {detail1,detail2} = this.restUserData.getChartDetails();
      console.log(detail1,detail2);
      this.chartLabel = [detail1.assessmentYear,detail2.assessmentYear];
      this.chartData = [detail1.grossTotalIncome,detail2.grossTotalIncome];
      // Register the Chart.js components
      Chart.register(...registerables);
    this.chart = new Chart('myChart', {
      type: 'bar', // Change this to 'line', 'pie', etc. for different chart types
      data: {
        labels: this.chartLabel,
        datasets: [{
          label: 'Income Tax ',
          data: this.chartData,
          backgroundColor: 'rgba(75, 192, 192, 0.2)',
          borderColor: 'rgba(75, 192, 192, 1)',
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
}
}
