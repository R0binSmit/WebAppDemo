import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { Country } from './country.model';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private url = "Countries"

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Country[]> {
    return this.httpClient.get<Country[]>(`${environment.apiUrl}/${this.url}`);
  }

  public get(id: number) {
    return this.httpClient.get<Country>(`${environment.apiUrl}/${this.url}/${id}`)
  }
}
