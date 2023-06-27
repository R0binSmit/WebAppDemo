import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { IAddress } from './address.interface';
import { Address } from './address.model';

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  private url = "Addresses"
  addressesChanged = new EventEmitter<IAddress[]>();

  constructor(private httpClient: HttpClient) { }

  private getAllAddresses(): IAddress[] {
    let addresses: IAddress[] = [];
    this.getAll().subscribe(data => { addresses = data; });
    return addresses;
  }

  public getAll(): Observable<IAddress[]> {
    return this.httpClient.get<IAddress[]>(`${environment.apiUrl}/${this.url}`);
  }

  public get(id: number): Observable<IAddress> {
    return this.httpClient.get<IAddress>(`${environment.apiUrl}/${this.url}/${id}`);
  }

  public update(address: Address) : Observable<any> {
    let result = this.httpClient.put<any>(`${environment.apiUrl}/${this.url}`, address);
    this.addressesChanged.emit(this.getAllAddresses());
    return result;
  }

  public create(addres: Address): Observable<IAddress> {
    let restult =  this.httpClient.post<IAddress>(`${environment.apiUrl}/${this.url}`, addres);
    this.addressesChanged.emit(this.getAllAddresses());
    return restult;
  }

  public delete(addressId: number): Observable<any> {
    let result = this.httpClient.delete<any>(`${environment.apiUrl}/${this.url}/${addressId}`);
    this.addressesChanged.emit(this.getAllAddresses());
    return result;
  }
}
