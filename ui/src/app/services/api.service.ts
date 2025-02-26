import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Password } from '../models/password';
import { Application } from '../models/application';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = environment.apiUrl;
  private apiKey = environment.apiKey;

  constructor(private http: HttpClient) { }

  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'x-api-key': this.apiKey
    });
  }

  // Méthodes pour les mots de passe
  getPasswords(): Observable<Password[]> {
    return this.http.get<Password[]>(`${this.apiUrl}/passwords`, { headers: this.getHeaders() });
  }

  addPassword(password: any): Observable<Password> {
    return this.http.post<Password>(`${this.apiUrl}/passwords`, password, { headers: this.getHeaders() });
  }

  deletePassword(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/passwords/${id}`, { headers: this.getHeaders() });
  }

  // Méthodes pour les applications
  getApplications(): Observable<Application[]> {
    return this.http.get<Application[]>(`${this.apiUrl}/applications`, { headers: this.getHeaders() });
  }

  addApplication(application: any): Observable<Application> {
    return this.http.post<Application>(`${this.apiUrl}/applications`, application, { headers: this.getHeaders() });
  }
}