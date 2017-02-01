//
//  LoginViewController.swift
//  LegoApp
//
//  Created by Helena Tamburić on 17/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import UIKit

import Alamofire
import MBProgressHUD
import SVProgressHUD
import Unbox


class LoginViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        
        username?.text = "zvonimir.vanjak@gmail.com"
        password?.text = "zvonimir"
        
        let attributes = ["username": "adis", "password": "test"]
        let data = ["data": ["type": "users", "attributes": attributes]]
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
    
  
    @IBOutlet weak var username: UITextField!
    
    
    @IBOutlet weak var password: UITextField!
    
    @IBAction func LoginUser(_ sender: UIButton) {
        guard let username = username?.text, username.characters.count > 0, let password = password?.text, password.characters.count > 0 else {
            
            let alert = UIAlertController(title: "Whoa there!", message: "Please enter username and password", preferredStyle: .alert)
            
            let okAction = UIAlertAction(title: "Ok", style: .default, handler: nil)
            
            alert.addAction(okAction)
            
            present(alert, animated: true, completion: nil)
            
            return
        }
        
        // Now onto networking
        let parameters: Parameters = [
            "Email": username,
            "Password": password
        ]
     
        Alamofire.request("http://mylego.local/api/UserApi/Login", method: .post, parameters: parameters, encoding: JSONEncoding.default, headers: nil).responseJSON { (response:DataResponse<Any>) in
            
            switch(response.result) {
                
            case .success(_):
                let statusCode = response.response?.statusCode
                
                if statusCode==200{
                print("Response String: \(response.result.value) and  \(response.result.value)")
                SVProgressHUD.showSuccess(withStatus: "")
                
                if let data = response.data {
                    // data postoji samo ovdje unutra
                    do {
                    
                        let user: User = try unbox(data: data)
                        print("Saving user \(user.id)")
                        CurrentUser.user =  "\(user.id)"
                        print ("User is at login \(CurrentUser.user)")
                        /*
                        let navViewController = self.storyboard?.instantiateViewController(withIdentifier: "NavigationView") as! UINavigationController
                        //loginViewController.user = user
                        self.navigationController?.pushViewController(navViewController, animated: true)*/
                        
                    } catch _ {
                        
                        // javit korisniku da ne valja nesto opet
                        // al mi znamo da ne valja json
                    }
                } else {
                    
                    // javit korisniku da je nesto crklo, i da proba poslije
                }
                }
                    
                else{
                    SVProgressHUD.showError(withStatus: "Email ili lozinka nisu ispravni")
                        //let storyboard = UIStoryboard(name: "MainStoryboard", bundle: nil)
                    /*
                        let yourVariable = storyboard.instantiateViewControllerWithIdentifier("LoginViewController") as! UIViewController
                    
                        self.presentViewController(yourVariable, animated: true, completion: nil)*/
                }
                
            case .failure(let error):
                SVProgressHUD.showError(withStatus: "\(error.localizedDescription)")
                
            }
            
        }
        
        SVProgressHUD.show()
        
        
        
        
    
    
    

}
}
