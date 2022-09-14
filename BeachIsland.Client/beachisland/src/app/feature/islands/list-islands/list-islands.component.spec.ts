import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListIslandsComponent } from './list-islands.component';

describe('ListIslandsComponent', () => {
  let component: ListIslandsComponent;
  let fixture: ComponentFixture<ListIslandsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListIslandsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListIslandsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
