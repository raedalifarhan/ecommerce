import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './models/product';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'client';
  products!: IProduct[];

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get<IPagination>("http://localhost:5052/api/products").subscribe(
      (response: IPagination) => {
        this.products = response.data;
      }, error => {
        console.log(error);
      });
  }
}
