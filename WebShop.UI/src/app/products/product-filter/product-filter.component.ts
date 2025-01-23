import { Component, EventEmitter, inject, Output } from '@angular/core';
import { CategoriesService } from '../../categories/categories.service';
import { CommonModule } from '@angular/common';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-product-filter',
  imports: [NgbDropdownModule, CommonModule],
  templateUrl: './product-filter.component.html',
  styleUrl: './product-filter.component.scss'
})
export class ProductFilterComponent {
  @Output() categorySelected = new EventEmitter<string | null>();

  categoriesService = inject(CategoriesService);
  categories: string[] = [];
  selectedCategory: string | null = null;

  constructor() {
    this.categoriesService.getCategories().subscribe((categories) => {
      this.categories = categories;
    });
  }

  selectCategory(category: string | null) {
    this.selectedCategory = category;
    this.categorySelected.emit(category);
  }
}
