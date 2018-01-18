import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuRouterComponent } from './menu-router.component';

describe('MenuRouterComponent', () => {
  let component: MenuRouterComponent;
  let fixture: ComponentFixture<MenuRouterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuRouterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuRouterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
