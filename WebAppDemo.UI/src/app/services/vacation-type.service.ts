import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { VacationType } from '../vacation-types/vacation-type';

@Injectable({
  providedIn: 'root'
})
export class VacationTypeService {
  private url = "VacationTypes"

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<VacationType[]> {
    return this.httpClient.get<VacationType[]>(`${environment.apiUrl}/${this.url}`);
  }

  public get(id: number) {
    return this.httpClient.get<VacationType>(`${environment.apiUrl}/${this.url}/${id}`)
  }
}
