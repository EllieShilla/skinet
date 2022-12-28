import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IOrder } from '../shared/models/order';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getOrders() {
    return this.http.get(this.baseUrl + 'orders').pipe(
      map((orders: IOrder[]) => {
        return orders.sort((a, b) => {
          return <any>new Date(b.orderDate) - <any>new Date(a.orderDate);
        });
      })
    );
  }

  getOrderById<IOrder>(id: string) {
    return this.http.get(this.baseUrl + 'orders/' + id).pipe(
      map((order: IOrder) => {
        return order;
      })
    );
  }
}
