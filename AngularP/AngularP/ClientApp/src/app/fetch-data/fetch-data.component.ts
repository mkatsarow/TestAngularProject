import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  styles: ['#batman { background-color: yellow;}',
    'td {border: 1px solid #dddddd}'],

//  td, th {
//    border: 1px solid #dddddd;
//    text- align: center;
//padding: 8px;
//}
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  location: string;
  maxTemperatureC: number;
  maxTemperatureF: number;
  minTemperatureC: number;
  minTemperatureF: number;
  summary: string;
  image: string;
  hours: number[];
  title: string; 
}
