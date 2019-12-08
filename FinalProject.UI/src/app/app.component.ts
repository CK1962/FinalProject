import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FinalProjectUI';

  weatherData: string = "";
  weatherImageUrl: string = "";

  constructor(private http: HttpClient) {
    const url: string = "https://api.weather.gov/gridpoints/LUB/48,32/forecast";
    this.http.get<any>(url).subscribe(data => {
      this.weatherData = data.properties.periods[0].temperature + ' degrees';
      this.weatherImageUrl = data.properties.periods[0].icon;
    });
  }


}
