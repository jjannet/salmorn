import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CartBoxTopComponent } from './cart-box-top.component';

describe('CartBoxTopComponent', () => {
  let component: CartBoxTopComponent;
  let fixture: ComponentFixture<CartBoxTopComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CartBoxTopComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CartBoxTopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
