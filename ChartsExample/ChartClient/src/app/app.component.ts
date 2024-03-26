import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import  * as   Highcharts from "highcharts";
import { HighchartsChartComponent, HighchartsChartModule } from 'highcharts-angular';
import  * as   signalR from "@microsoft/signalr";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,HighchartsChartModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
 Highcharts: typeof Highcharts=Highcharts;
 chartOptions:Highcharts.Options={
  title:{
    text:"Title"
  },
  subtitle:{
    text:"Subtitle"
  },
  yAxis:{
    title:{
      text:"Y Axis"
    }
  },
  xAxis:{
    accessibility:{
      rangeDescription:"2019-2020"
    }
  },
  legend:{
    layout:"vertical",
    align:"right",
    verticalAlign:"middle"
  },
  series: [{
    name: "X",
    type: "line",
    data: [1000, 2000, 3000]
  },
  {
    name: "Y",
    type: "line",
    data: [4000, 2000, 1000]
  },
  {
    name: "Z",
    type: "line",
    data: [700, 800, 900]
  }],
  plotOptions:{
    series:{
      label:{
        connectorAllowed:true
      },
      pointStart:100
    }
  }
 }
}
