import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { ICountry } from './country.interface';
import { Country } from './country.model';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private url = "Countries"

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<ICountry[]> {
    return this.httpClient.get<ICountry[]>(`${environment.apiUrl}/${this.url}`);
  }

  public get(id: number) {
    return this.httpClient.get<ICountry>(`${environment.apiUrl}/${this.url}/${id}`)
  }

  public update(country: ICountry) : Observable<any> {
    return this.httpClient.put<any>(`${environment.apiUrl}/${this.url}`, country);
  }

  public create(country: Country): Observable<ICountry> {
    return this.httpClient.post<Country>(`${environment.apiUrl}/${this.url}`, country);
  }

  public delete(countryId: number): Observable<any> {
    return this.httpClient.delete<any>(`${environment.apiUrl}/${this.url}/${countryId}`);
  }
}
