import { Injectable } from '@angular/core';
import { IHouse } from '../interfaces/ihouse';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HouseService {
  houseList: IHouse[] = [];

  constructor(private http: HttpClient) {
    this.load();
  }

  private isLoaded: boolean = false;
  async load() {
    const url: string = "https://localhost:44331/api/House";
    this.http.get<IHouse[]>(url).subscribe(data => {
      this.houseList = data as IHouse[];
      this.isLoaded = true;
    });
  }

  delete(houseId: number) {
    // delete API
    const url: string = "https://localhost:44331/api/House/" + houseId;
    this.http.delete<IHouse[]>(url).subscribe(data => {
      this.load();
    });
  }

  getAll(): IHouse[] {
    if (!this.isLoaded) {
      this.load();
    }
    return this.houseList;
  }

  add(house: IHouse) {
    // add API
    const url: string = "https://localhost:44331/api/House/";
    this.http.post<IHouse[]>(url, house).subscribe(data => {
      this.load();
    });
  }

  update(houseId: number): void {
    const house = this.houseList.find(x => x.id === houseId);

    // update API
    const url: string = "https://localhost:44331/api/House/" + house.id;
    this.http.put<IHouse[]>(url, house).subscribe(data => {
      this.load();
    });
  }
}