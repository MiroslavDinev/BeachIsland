import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminIslandComponent } from './admin-island.component';

describe('AdminIslandComponent', () => {
  let component: AdminIslandComponent;
  let fixture: ComponentFixture<AdminIslandComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminIslandComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminIslandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
