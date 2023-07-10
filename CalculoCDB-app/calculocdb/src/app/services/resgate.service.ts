import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Rendimento } from '../interface/rendimento';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ResgateService {

  private apiResgateUrl = "http://localhost:3009/Resgate"
  private headers = new Headers({'Content-Type':'application/json'})
  
  httpHeaders!: HttpHeaders;

  constructor(private http: HttpClient) {
    this.httpHeaders = new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  calcular(rendimento: Rendimento): Observable<any> {
    
    return this.http.post(this.apiResgateUrl, rendimento, { headers: this.httpHeaders });
  }


}
