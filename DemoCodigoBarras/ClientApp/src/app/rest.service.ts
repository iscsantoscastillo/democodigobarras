import { Injectable } from '@angular/core';
import { Base97I } from '../app/models/Base97.interface';
import { ResponseI } from '../app/models/response.interface';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class RestService {

  url: string = 'https://localhost:44360/WeatherForecast';
  //url: string = 'http://localhost:8003/WeatherForecast';
  constructor(private http: HttpClient) { }

  consumir(form: Base97I): Observable<ResponseI> {
    let direccion = this.url;
    return this.http.post<ResponseI>(direccion, form);
  }
}
