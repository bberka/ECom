import Link from "next/link";
import Router, { useRouter } from "next/router";
import { classNames } from "primereact/utils";
import React, {
  forwardRef,
  useContext,
  useImperativeHandle,
  useRef,
} from "react";
import { LayoutContext } from "./context/layoutcontext";

import { Menu } from "primereact/menu";
import { Toast } from "primereact/toast";
import { Avatar } from "primereact/avatar";
import { Button } from "primereact/button";

const AppTopbar = forwardRef((props, ref) => {
  const { layoutConfig, layoutState, onMenuToggle, showProfileSidebar } =
    useContext(LayoutContext);
  const menubuttonRef = useRef(null);
  const topbarmenuRef = useRef(null);
  const topbarmenubuttonRef = useRef(null);
  const menuLeft = useRef(null);
  const menuRight = useRef(null);

  useImperativeHandle(ref, () => ({
    menubutton: menubuttonRef.current,
    topbarmenu: topbarmenuRef.current,
    topbarmenubutton: topbarmenubuttonRef.current,
  }));
  let items = [
    {
      label: "Profile",
      icon: "pi pi-fw pi-user",
      command : (event) => {window.location = "/profile"},

    },
    {
      label: "Settings",
      icon: "pi pi-fw pi-cog",
      command : (event) => {window.location = "/settings"},
    },
    { separator: true },
    {
      label: "Logout",
      icon: "pi pi-fw pi-arrow-left",
      command : (event) => {window.location = "/logout"},

    },
  ];
  return (
    <div className="layout-topbar">
      <Link href="/dashboard" className="layout-topbar-logo">
        <img
          src={`/layout/images/logo-${
            layoutConfig.colorScheme !== "light" ? "white" : "dark"
          }.svg`}
          width="47.22px"
          height={"35px"}
          widt={"true"}
          alt="logo"
        />
        <span>ECOM</span>
      </Link>

      <button
        ref={menubuttonRef}
        type="button"
        className="p-link layout-menu-button layout-topbar-button"
        onClick={onMenuToggle}
      >
        <i className="pi pi-bars" />
      </button>

      <button
        ref={topbarmenubuttonRef}
        type="button"
        className="p-link layout-topbar-menu-button layout-topbar-button"
        onClick={showProfileSidebar}
      >
        <i className="pi pi-ellipsis-v" />
      </button>

      <div
        ref={topbarmenuRef}
        className={classNames("layout-topbar-menu", {
          "layout-topbar-menu-mobile-active": layoutState.profileSidebarVisible,
        })}
      >
        <button type="button" className="p-link layout-topbar-button">
          <i className="pi pi-calendar"></i>
          <span>Calendar</span>
        </button>

        <div className="">
          <Menu model={items} popup ref={menuLeft} id="popup_menu_left" />
          <Button
            icon="pi pi-align-left"
            className="p-link layout-topbar-button"
            onClick={(event) => menuLeft.current.toggle(event)}
            aria-controls="popup_menu_left"
            aria-haspopup
          >
            <i className="pi pi-user"></i>
            <span>Profile</span>
          </Button>
        </div>
      </div>
    </div>
  );
});

export default AppTopbar;
