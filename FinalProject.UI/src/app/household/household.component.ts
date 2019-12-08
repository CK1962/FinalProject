import { Component, OnInit } from '@angular/core';
import { HouseService } from '../services/house.service';
import { IHouse } from '../interfaces/ihouse';

@Component({

  selector: 'household',
  templateUrl: './household.component.html',
  styleUrls: ['./household.component.scss']
})
export class HouseholdComponent implements OnInit {
  isEditingHouseId: number = 0;

  constructor(private HouseService: HouseService) { }

  ngOnInit() { }

  refreshHouses(): void {
    this.HouseService.load();
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
    this.HouseService.update(this.isEditingHouseId)
    this.isEditingHouseId = 0;
  }

  addHouse(): void {
    this.HouseService.add({
      id: 0,
      name: '',
      city: '',
      children: ''
    });
  }
}