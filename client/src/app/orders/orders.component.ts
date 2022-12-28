import { Component, OnInit } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { BreadcrumbService } from 'xng-breadcrumb';
import { IOrder } from '../shared/models/order';
import { OrdersService } from './orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss'],
})
export class OrdersComponent implements OnInit {
  orders: IOrder[];

  private order: IOrder;
  constructor(
    private ordersService: OrdersService,
    private router: Router
  ) {}

  ngOnInit() {
    this.getBasicInformationAboutAllOrders();
  }

  getBasicInformationAboutAllOrders() {
    this.ordersService.getOrders().subscribe(
      (orders: IOrder[]) => {
        this.orders = orders;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  loadOrder(id: string) {
    this.ordersService.getOrderById(id).subscribe(
      (order: IOrder) => {
        this.order = order;
        this.router.navigate(['orders/:id'], {
          state: { orderData: this.order },
        });
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
