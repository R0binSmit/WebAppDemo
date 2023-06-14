import { HttpClient, HttpResponse, HttpStatusCode } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { Address } from './address.model';
import { UpdateAddressDto } from './edit-address-dialog/updateAddress.model';
import { CreateAddressDto } from './create-address-dialog/create-address.model';

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  private url = "Addresses"

  constructor(private httpClient: HttpClient) { }

  public getAll(): Observable<Address[]> {
    return this.httpClient.get<Address[]>(`${environment.apiUrl}/${this.url}`);
  }

  public get(id: number): Observable<Address> {
    return this.httpClient.get<Address>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public update(address: UpdateAddressDto) : Observable<any> {
    return this.httpClient.put<any>(`${environment.apiUrl}/${this.url}`, address);
  }

  public create(addres: CreateAddressDto): Observable<Address> {
    return this.httpClient.post<Address>(`${environment.apiUrl}/${this.url}`, addres);
  }

  public delete(addressId: number): Observable<any> {
    return this.httpClient.delete<any>(`${environment.apiUrl}/${this.url}/${addressId}`,);
  }
}
