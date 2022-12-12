export class ShopParams {
  brandId = 0;
  typeId = 0;
  sort = 'name';
  pageNumber: number = 1;
  pageSize: number = 6;
  totalCount = 0;
  search: string;

  getCurrentPageMinProductNum() {
    let num = (this.pageNumber - 1) * this.pageSize + 1;
    return num.toString();
  }

  getCurrentPageMaxProductNum() {
    let num =
      this.pageNumber * this.pageSize > this.totalCount
        ? this.totalCount
        : this.pageNumber * this.pageSize;
    return num.toString();
  }
}
