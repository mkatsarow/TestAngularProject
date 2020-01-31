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
    '.headerMain { height: 106px; background: url(Img/Winter.jfif) repeat - x 0 - 27px;}',
    'li { display: inline; }',
    '.topnav { background- color: #333; overflow: hidden; border: solid }',
    '.topnav a { float: left; color: #f2f2f2; text- align: center; padding: 14px 16px; text - decoration: none; font - size: 17px;}',
    '.topnav a: hover { background - color: #ddd; color: black;}',
    '.topnav a.active { background - color: #4CAF50; color: white;}',
    'body { margin: 0; font- family: Arial, Helvetica, sans - serif;}'

  ],
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
