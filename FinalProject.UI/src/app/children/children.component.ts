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
  childId: number = 1;
  isEditingChildId: number = 0;

  constructor(
    private ChildService: ChildService,
    private HouseService: HouseService) { }

  ngOnInit() { }

  get houseList(): string[] {
    // console.log(this.HouseService.houseList.map((el) => { return el.name; }));
    return this.HouseService.houseList.map((el) => { return el.name; });
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
    this.isEditingChildId = 0;
  }

  addChild(): void {
    this.childId++;
    this.ChildService.add({
      id: this.childId,
      name: '',
      dob: '',
      moveInDate: '',
      house: ''
    });
  }
}

