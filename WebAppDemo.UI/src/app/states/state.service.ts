import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { State } from './state.model';

@Injectable({
  providedIn: 'root'
})
export class StateService {
  private url = "States"

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<State[]> {
    return this.httpClient.get<State[]>(`${environment.apiUrl}/${this.url}`);
  }

  public get(id: number) {
    return this.httpClient.get<State>(`${environment.apiUrl}/${this.url}/${id}`)
  }
}
