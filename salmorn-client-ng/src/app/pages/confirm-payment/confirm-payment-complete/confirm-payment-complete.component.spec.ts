import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmPaymentCompleteComponent } from './confirm-payment-complete.component';

describe('ConfirmPaymentCompleteComponent', () => {
  let component: ConfirmPaymentCompleteComponent;
  let fixture: ComponentFixture<ConfirmPaymentCompleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfirmPaymentCompleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmPaymentCompleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
