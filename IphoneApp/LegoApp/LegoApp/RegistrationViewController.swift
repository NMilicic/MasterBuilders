//
//  RegistrationViewController.swift
//  LegoApp
//
//  Created by Helena Tamburić on 17/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import UIKit


import Alamofire
import Unbox
import SVProgressHUD



class RegistrationViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    public enum HTTPMethod: String {
        case options = "OPTIONS"
        case get     = "GET"
        case head    = "HEAD"
        case post    = "POST"
        case put     = "PUT"
        case patch   = "PATCH"
        case delete  = "DELETE"
        case trace   = "TRACE"
        case connect = "CONNECT"
    }
     public typealias Parameters = [String: Any]
    
    @IBOutlet weak var name: UITextField!
 
    @IBOutlet weak var lastname: UITextField!
    @IBOutlet weak var password: UITextField!
    
    @IBOutlet weak var email: UITextField!
    
    @IBAction func registerUser(_ sender: UIButton) {
        
        
        guard let name = name?.text, name.characters.count > 0, let password = password?.text, password.characters.count > 0,let email = email?.text,  email.characters.count > 0,let lastname = lastname?.text , lastname.characters.count > 0
                else {
            
            let alert = UIAlertController(title: "Whoa there!", message: "Please enter all info", preferredStyle: .alert)
            
            let okAction = UIAlertAction(title: "Ok", style: .default, handler: nil)
            
            alert.addAction(okAction)
            
            present(alert, animated: true, completion: nil)
            
            return
        }
        // Now onto networking
        let parameters: Parameters = [
            "Email": email,
            "Password": password,
            "FirstName":name,
            "LastName":lastname
        ]
        
        Alamofire.request("http://mylego.local/api/UserApi/Register", method: .post, parameters: parameters, encoding: JSONEncoding.default, headers: nil).responseJSON { (response:DataResponse<Any>) in
            
            switch(response.result) {
                
            case .success(_):
                let statusCode = response.response?.statusCode;
                
                if statusCode==200{
                    print("Response String: \(response.result.value) and  \(response.result.value)")
                    SVProgressHUD.showSuccess(withStatus: "")
                    
                    if let data = response.data {
                        // data postoji samo ovdje unutra
                        do {
                            
                            let user: User = try unbox(data: data)
                            print("\(user.email)")
                            let loginViewController = self.storyboard?.instantiateViewController(withIdentifier: "LoginView") as! LoginViewController
                            //loginViewController.user = user
                            self.navigationController?.pushViewController(loginViewController, animated: true)
                        } catch _ {
                            // javit korisniku da ne valja nesto opet
                            // al mi znamo da ne valja json
                        }
                    } else {
                        // javit korisniku da je nesto crklo, i da proba poslije
                    }
                }
                    
                else{
                    SVProgressHUD.showError(withStatus: "\(statusCode)")
                  
          
                }
                
            case .failure(let error):
                SVProgressHUD.showError(withStatus: "\(error.localizedDescription)")
                
            }
            
        }
        
        SVProgressHUD.show()
 
    }
    
   
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        self.view.endEditing(true)
    }

}


