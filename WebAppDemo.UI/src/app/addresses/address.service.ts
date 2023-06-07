import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { Address } from './address.model';

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  private url = "Addresses"

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Address[]> {
    return this.httpClient.get<Address[]>(`${environment.apiUrl}/${this.url}`);
  }

  public get(id: number) {
    return this.httpClient.get<Address>(`${environment.apiUrl}/${this.url}/${id}`)
  }
}
