import { HttpClient, HttpResponse, HttpStatusCode } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
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
  addressesChanged = new EventEmitter<Address[]>();

  constructor(private httpClient: HttpClient) { }

  private getAllAddresses(): Address[] {
    let addresses: Address[] = [];
    this.getAll().subscribe(data => { addresses = data; });
    return addresses;
  }

  public getAll(): Observable<Address[]> {
    return this.httpClient.get<Address[]>(`${environment.apiUrl}/${this.url}`);
  }

  public get(id: number): Observable<Address> {
    return this.httpClient.get<Address>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public update(address: UpdateAddressDto) : Observable<any> {
    let result = this.httpClient.put<any>(`${environment.apiUrl}/${this.url}`, address);
    this.addressesChanged.emit(this.getAllAddresses());
    return result;
  }

  public create(addres: CreateAddressDto): Observable<Address> {
    let restult =  this.httpClient.post<Address>(`${environment.apiUrl}/${this.url}`, addres);
    this.addressesChanged.emit(this.getAllAddresses());
    return restult;
  }

  public delete(addressId: number): Observable<any> {
    let result = this.httpClient.delete<any>(`${environment.apiUrl}/${this.url}/${addressId}`,);
    this.addressesChanged.emit(this.getAllAddresses());
    return result;
  }
}
