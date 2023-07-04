import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { IState } from './state.inteface';

@Injectable({
  providedIn: 'root'
})
export class StateService {
  private url = "States"

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<IState[]> {
    return this.httpClient.get<IState[]>("https://localhost:7199/States");
  }

  public get(id: number) {
    return this.httpClient.get<IState>(`https://localhost:7199/States/${id}`)
  }

  public getByCountryId(countryId: number): Observable<IState[]> {
    return this.httpClient.get<IState[]>(`https://localhost:7199/States/GetByCountryId/${countryId}`)
  }
}
