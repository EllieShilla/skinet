import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.scss'],
})
export class SectionHeaderComponent {
  breadcrumb$: Observable<any[]>; //if some Observable add $ to end of it
  constructor(private bcService: BreadcrumbService) {}

  ngOnInit() {
    this.breadcrumb$ = this.bcService.breadcrumbs$;
  }
}
