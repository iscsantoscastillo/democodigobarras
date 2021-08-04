import { Component } from '@angular/core';
import { RestService } from '../rest.service';
import { Barra } from '../barra.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  barra: Barra;
  constructor(private RestService: RestService) { }

  elementType = 'svg';
  value = '00000';
  format = 'CODE128';
  lineColor = '#000000';
  width = 2;
  height = 100;
  displayValue = true;
  fontOptions = '';
  font = 'monospace';
  textAlign = 'center';
  textPosition = 'bottom';
  textMargin = 2;
  fontSize = 20;
  background = '#ffffff';
  margin = 10;
  marginTop = 10;
  marginBottom = 10;
  marginLeft = 10;
  marginRight = 10;

  get values(): string[] {
    return this.value.split('\n');
  }
  codeList: string[] = [
    '', 'CODE128',
    'CODE128A', 'CODE128B', 'CODE128C',
    'UPC', 'EAN8', 'EAN5', 'EAN2',
    'CODE39',
    'ITF14',
    'MSI', 'MSI10', 'MSI11', 'MSI1010', 'MSI1110',
    'pharmacode',
    'codabar'
  ];
  prueba(codigo: string): void {

    this.RestService.get('https://localhost:44360/WeatherForecast').subscribe(respuesta => {
      //this.barra = respuesta;
      console.log(respuesta);
      this.barra = <any>respuesta;
      this.value = this.barra.cadena;
    })        
  }
}
