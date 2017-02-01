//
//  FirstViewController.swift
//  LegoApp
//
//  Created by Helena Tamburić on 17/01/2017.
//  Copyright © 2017 Helena Tamburić. All rights reserved.
//

import UIKit
import Alamofire
import SVProgressHUD
import Unbox


class SetsViewController: UIViewController, UITableViewDataSource,UITableViewDelegate {
   
   
    @IBOutlet weak var tableView: UITableView!
   
  
    var mysets: [MySet] = []
   // var user: User? = nil
    
  
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        print("otvoreni svi setovi")
        getSetsList()
       
    }
    
  
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    
    
    func getSetsList() {
        
      
        SVProgressHUD.show()
        
       Alamofire.request("http://mylego.local/api/LSetApi/GetAll?take=20",headers: nil).responseJSON { (response:DataResponse<Any>) in
            switch response.result {
            case .success:
                SVProgressHUD.showSuccess(withStatus: "")
                if let data = response.data {
                    do {
                        var myset=[MySet]()
                        myset = try unbox(data: data)
                        print("\(myset)")
                        self.mysets = myset
                        self.tableView.reloadData()
                    } catch _ {
                        print("krepalo")                    }
                } else {
                    // javit korisniku da je nesto crklo, i da proba poslije
                }
                
            case .failure(let error):
              
                SVProgressHUD.showError(withStatus: "\(error.localizedDescription)")
            }
        }
    }
    func numberOfSectionsInTableView(tableView: UITableView) -> Int {
        return 1
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        print("\(mysets.count)")
        return mysets.count
    }
    
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = self.tableView.dequeueReusableCell(withIdentifier: "cell") as! CustomViewCell
        //print("ucitavam");
      
        cell.id.text = String(mysets[indexPath.row].Id)
        cell.name.text = mysets[indexPath.row].Ime
        cell.descript.text = mysets[indexPath.row].Opis
        cell.noOfParts.text = String(mysets[indexPath.row].DijeloviBroj)
        cell.year.text = String(mysets[indexPath.row].GodinaProizvodnje)
        cell.theme.text = String(mysets[indexPath.row].NazivTema)
        cell.instructionsSets.text = String(mysets[indexPath.row].UputeUrl)
        
        /*
         if mysets[indexPath.row].Slike != "null" {
         let url: NSURL = NSURL(string: mysets[indexPath.row].Slike)!
        // TODO add reachability pod and connection check on app start
         let data : NSData = NSData(contentsOf: url as URL)!
         cell.photo?.image = UIImage(data: data as Data)
        
        }*/
        return cell
    }
   

    
    
    
}




    
    



