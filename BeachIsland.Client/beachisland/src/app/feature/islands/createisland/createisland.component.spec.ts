import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateislandComponent } from './createisland.component';

describe('CreateislandComponent', () => {
  let component: CreateislandComponent;
  let fixture: ComponentFixture<CreateislandComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateislandComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateislandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
