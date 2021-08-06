import { Component, OnInit } from '@angular/core';
import { RestService } from '../rest.service';
import { Barra } from '../barra.component';
import { Base97I } from '../models/Base97.interface';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  loginForm = new FormGroup({
    convenio: new FormControl('C0001', Validators.required),
    referencia: new FormControl('SL202186756521PSWS', Validators.required),
    fecha: new FormControl('10/08/2021', Validators.required),
    importe: new FormControl('410.78', Validators.required)

  })

  barra: Barra;
  constructor(private rest: RestService) { }

  ngOnInit(): void {
    
  }
  
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
    
    
  }

  onPress(form: Base97I) {
   
    this.rest.consumir(form).subscribe(data => {
      //Se asigna el valor de respuesta del API rest.
      this.value = data.cadena
    })
  }
}
