import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PartnerIslandsComponent } from './partner-islands.component';

describe('PartnerIslandsComponent', () => {
  let component: PartnerIslandsComponent;
  let fixture: ComponentFixture<PartnerIslandsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PartnerIslandsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PartnerIslandsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
