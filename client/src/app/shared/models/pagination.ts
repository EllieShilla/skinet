import { IProduct } from './product';

export interface IPagination {
  PageIndex: number;
  pageSize: number;
  count: number;
  data: IProduct[];
};
