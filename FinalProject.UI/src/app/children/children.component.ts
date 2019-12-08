import { Component, OnInit } from '@angular/core';
import { ChildService } from '../services/child.service';
import { HouseService } from '../services/house.service';
import { IChild } from '../interfaces/ichild';


@Component({
  selector: 'children',
  templateUrl: './children.component.html',
  styleUrls: ['./children.component.scss']
})
export class ChildrenComponent implements OnInit {
  isEditingChildId: number = 0;

  constructor(
    private ChildService: ChildService,
    private HouseService: HouseService) { }

  ngOnInit() { }

  get houseList(): any[] {
    return this.HouseService.houseList.map((el) => { return { houseId: el.id, houseName: el.name } });
  }

  get childList(): IChild[] {
    return this.ChildService.childList;
  }

  deleteChild(childId: number): void {
    this.ChildService.delete(childId);
  }

  editChild(childId: number): void {
    this.isEditingChildId = childId;
  }

  cancelEditChild(): void {
    this.isEditingChildId = 0;
  }

  saveEditChild(): void {
    this.ChildService.update(this.isEditingChildId)
    this.isEditingChildId = 0;

    this.HouseService.load();
  }

  addChild(): void {
    this.ChildService.add({
      id: 0,
      name: '',
      dob: '',
      moveInDate: '',
      houseId: null,
      houseName: null
    });
  }
}
