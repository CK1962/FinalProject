import { Component, OnInit } from '@angular/core';
import { HouseService } from '../services/house.service';
import { IHouse } from '../interfaces/ihouse';

@Component({

  selector: 'household',
  templateUrl: './household.component.html',
  styleUrls: ['./household.component.scss']
})
export class HouseholdComponent implements OnInit {

  houseId: number = 1;
  isEditingHouseId: number = 0;
  constructor(private HouseService: HouseService) {
  }

  ngOnInit() {
  }

  get houseList(): IHouse[] {
    return this.HouseService.houseList;
  }

  deleteHouse(houseId: number): void {
    this.HouseService.delete(houseId);
  }

  editHouse(houseId: number): void {
    this.isEditingHouseId = houseId;
  }

  cancelEditHouse(): void {
    this.isEditingHouseId = 0;
  }

  saveEditHouse(): void {
    this.isEditingHouseId = 0;
  }

  addHouse(): void {
    this.houseId++;
    this.HouseService.add({
      id: this.houseId,
      name: '',
      city: '',
      children: ''
    });
  }

}