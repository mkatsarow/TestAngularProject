import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  styles: [
    'td {border: 2px solid #dddddd}',
    'table.myTable { border: none; }',
    '#myFooter {border: 2px solid #dddddd}',
    '#myImg { border: 20; }',
    '.date-cell { border: none; }',
  ],
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];
  public forecasts2: WeatherForecast2[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast2[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts2 = result;
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

interface WeatherForecast2 {
  id: string;
  Base: string;
  timezone: number;
  name: number;
  cod: number;
  wind: Wind;
  main: Main;
}
interface Wind {
  speed: number;
  deg: number;
}
interface Main {
  temp: number;
  feels_like: number;
  temp_min: number;
  temp_max: number;
  pressure: number;
  humidity: number;
}
