import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IslandDetailsComponent } from './island-details.component';

describe('IslandDetailsComponent', () => {
  let component: IslandDetailsComponent;
  let fixture: ComponentFixture<IslandDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IslandDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IslandDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
