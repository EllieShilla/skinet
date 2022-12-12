import { Component, Input, OnInit } from '@angular/core';
import { ShopParams } from '../../models/shopParams';

@Component({
  selector: 'app-pagin-header',
  templateUrl: './pagin-header.component.html',
  styleUrls: ['./pagin-header.component.scss'],
})
export class PaginHeaderComponent implements OnInit {
  @Input() totalCount: number;
  @Input() minNum: number;
  @Input() maxNum: number;
  constructor() {}

  ngOnInit(): void {}
}
