import { useRouter } from "next/router";
import React, { useContext, useState, useRef } from "react";
import AppConfig from "../layout/AppConfig";
import { Checkbox } from "primereact/checkbox";
import { Button } from "primereact/button";
import { Password } from "primereact/password";
import { LayoutContext } from "../layout/context/layoutcontext";
import { InputText } from "primereact/inputtext";
import { classNames } from "primereact/utils";
import { Toast } from "primereact/toast";
import { Message } from "primereact/message";
import { Messages } from "primereact/messages";
import * as Auth from "../service/auth";
import { AuthService } from "../service/service";

const LoginPage = () => {
  const [password, setPassword] = useState("");
  const [emailAddress, setEmailAddress] = useState("");
  const [checked, setChecked] = useState(false);
  const { layoutConfig } = useContext(LayoutContext);
  const toast = useRef(null);

  const router = useRouter();
  const containerClassName = classNames(
    "surface-ground flex align-items-center justify-content-center min-h-screen min-w-screen overflow-hidden",
    { "p-input-filled": layoutConfig.inputStyle === "filled" }
  );
  let isAuthenticated = Auth.isTokenExists();
  if (isAuthenticated) {
    router.push("/dashboard");
  }

  const login = async () => {
    // msgs.current.clear();
    var body = {
      emailAddress: emailAddress,
      password: password,
      rememberMe: checked,
    };
    let result = await AuthService.login(body);

    if (!result.status) {
        toast.current.show({
            severity: result.severity,
            summary: result.severityText,
            detail: result.message,
            life: 2000, 
          });
        return;
    }
    Auth.setAuthInfo(result.data);
    router.push("/dashboard");
  };

  function getClassNameForErrorMessage() {
    var hidden = errorMessage == "" ? "hidden" : "";
    return hidden + " mr-2";
  }

  return (
    <div className={containerClassName}>
      <div className="flex flex-column align-items-center justify-content-center">
        <img
          src={`/layout/images/logo-${
            layoutConfig.colorScheme === "light" ? "dark" : "white"
          }.svg`}
          alt="Sakai logo"
          className="mb-5 w-5rem flex-shrink-0"
        />
        <div
          className=""
          style={{
            borderRadius: "56px",
            padding: "0.3rem",
            background:
              "linear-gradient(180deg, var(--primary-color) 10%, rgba(33, 150, 243, 0) 30%)",
          }}
        >
          <div
            className="w-full surface-card py-8 px-5 sm:px-8"
            style={{ borderRadius: "53px" }}
          >
            <div className="text-center mb-5">
              <img
                src="/demo/images/login/avatar.png"
                alt="Image"
                height="50"
                className="mb-3"
              />
              <div className="text-900 text-3xl font-medium mb-3">Welcome!</div>
              <span className="text-600 font-medium">Sign in to continue</span>
            </div>

            <div>
              <Toast ref={toast} position="bottom-right" />
              <label
                htmlFor="email"
                className="block text-900 text-xl font-medium mb-2"
              >
                Email
              </label>
              <InputText
                inputid="email"
                type="text"
                placeholder="Email address"
                onChange={(e) => setEmailAddress(e.target.value)}
                className="w-full md:w-30rem mb-5"
                style={{ padding: "1rem" }}
              />
              <label
                htmlFor="password"
                className="block text-900 font-medium text-xl mb-2"
              >
                Password
              </label>
              <Password
                inputid="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="Password"
                toggleMask
                className="w-full mb-5"
                feedback={false}
                inputClassName="w-full p-3 md:w-30rem"
              ></Password>

              <div className="flex align-items-center justify-content-between mb-5 gap-5">
                <div className="flex align-items-center">
                  <Checkbox
                    inputid="rememberme1"
                    checked={checked}
                    onChange={(e) => setChecked(e.checked)}
                    className="mr-2"
                  ></Checkbox>
                  <label htmlFor="rememberme1">Remember me</label>
                </div>
                <a
                  className="font-medium no-underline ml-2 text-right cursor-pointer"
                  style={{ color: "var(--primary-color)" }}
                >
                  Forgot password?
                </a>
              </div>
              <Button
                label="Sign In"
                className="w-full p-3 text-xl"
                onClick={login}
              ></Button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

LoginPage.getLayout = function getLayout(page) {
  return (
    <React.Fragment>
      {page}
      <AppConfig simple />
    </React.Fragment>
  );
};
export default LoginPage;
