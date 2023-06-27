import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { IState } from './state.inteface';

@Injectable({
  providedIn: 'root'
})
export class StateService {
  private url = "States"

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<IState[]> {
    return this.httpClient.get<IState[]>(`${environment.apiUrl}/${this.url}`);
  }

  public get(id: number) {
    return this.httpClient.get<IState>(`${environment.apiUrl}/${this.url}/${id}`)
  }

  public getByCountryId(countryId: number): Observable<IState[]> {
    return this.httpClient.get<IState[]>(`${environment.apiUrl}/${this.url}/GetByCountryId/${countryId}`)
  }
}
