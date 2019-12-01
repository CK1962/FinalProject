import { Injectable } from '@angular/core';
import { IHouse } from '../interfaces/ihouse';

@Injectable({
  providedIn: 'root'
})
export class HouseService {
  houseList: IHouse[] = [];
  constructor() {
    const house1: IHouse = {
      id: 1,
      name: 'Keslin',
      city: 'Lubbock',
      children: 'Allyson; Matthew'
    };
    this.add(house1);
  }

  delete(houseId: number) {
    const index = this.houseList.findIndex(houseItem => houseItem.id === houseId);
    this.houseList.splice(index, 1);
  }

  getAll(): IHouse[] {
    return this.houseList;
  }

  add(house: IHouse) {
    this.houseList.push(house);
  }

  update(house: IHouse): void {
    var foundItem = this.houseList.find(x => x.id === house.id);
  }
}