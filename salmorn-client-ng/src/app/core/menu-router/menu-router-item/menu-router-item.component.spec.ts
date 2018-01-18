import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuRouterItemComponent } from './menu-router-item.component';

describe('MenuRouterItemComponent', () => {
  let component: MenuRouterItemComponent;
  let fixture: ComponentFixture<MenuRouterItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuRouterItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuRouterItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
