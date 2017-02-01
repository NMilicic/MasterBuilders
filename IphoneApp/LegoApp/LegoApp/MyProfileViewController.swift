//
//  MyProfileViewController.swift
//  LegoApp
//
//  Created by Helena Tamburić on 28/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import UIKit

class MyProfileViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    
    @IBAction func logout(_ sender: UIButton) {
        CurrentUser.user = ""
        let loginViewController = self.storyboard?.instantiateViewController(withIdentifier: "LoginView") as! LoginViewController
        //loginViewController.user = user
        self.navigationController?.pushViewController(loginViewController, animated: true)
    }


}
